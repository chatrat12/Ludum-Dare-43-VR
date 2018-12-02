using System.Collections.Generic;
using UnityEngine;
using UnityAsync;
using System.Threading.Tasks;

public class MattSaysGame : MonoBehaviour
{
    public int Score => Mathf.Max(_sequence.Count - 1, 0);

    private static Color[] _colors = new Color[]
    {
        Color.green,
        Color.red,
        Color.yellow,
        Color.blue
    };

    private static float[] _frequencies = new float[]
    {
        391, // G4
        329, // E4
        261, // C4
        195, // G3
        48   // G1
    };

    [SerializeField] MattSaysButton _buttonPrefab;
    [SerializeField] float _buttonSpacing;

    private MattSaysButton[] _buttons = new MattSaysButton[4];
    private List<int> _sequence = new List<int>();

    private async void Start()
    {
        SpawnButtons();

        while (true)
        {
            AddToSequence();
            await Recite();
            if (!await GetPlayerResponse())
                await DoGameOver();
        }
    }

    private void AddToSequence()
        => _sequence.Add(Random.Range(0, _buttons.Length));


    private async Task Recite()
    {
        // Pause
        await Await.Seconds(1);

        foreach (var buttonIndex in _sequence)
        {
            _buttons[buttonIndex].Lit = true;
            await Await.Seconds(0.5f);
            _buttons[buttonIndex].Lit = false;
            await Await.Seconds(0.5f);
        }
    }

    // Returns true if player played correct sequence.
    private async Task<bool> GetPlayerResponse()
    {
        var tcs = new TaskCompletionSource<bool>();

        int currentIndex = 0; // Keeps track of what part of the sequence the player is supposed to play.

        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;

            // Light up if already touched
            _buttons[i].Lit = _buttons[i].Input.Touched;

            // Add listeners for button interactions
            _buttons[i].Input.Pressed += (sender) => _buttons[index].Lit = true;
            _buttons[i].Input.Released += (sender) =>
            {
                // Pressed correct button in sequence
                if (index == _sequence[currentIndex])
                {
                    _buttons[index].Lit = false;
                    currentIndex++;
                    if (currentIndex == _sequence.Count) // If made it to end of sequence
                        tcs.SetResult(true);
                }
                else
                    tcs.SetResult(false);
            };
        }

        var result = await tcs.Task;
        // Remove listeners from buttons.
        foreach (var button in _buttons)
        {
            button.Lit = false;
            button.Input.RemoveHandlers();
        }
        return result;
    }

    private async Task DoGameOver()
    {
        // Clear the sequence
        _sequence.Clear();
        await Await.Seconds(0.5f);
        for (int i = 0; i < 5; i++)
        {
            foreach (var button in _buttons)
                button.Lit = true;
            await Await.Seconds(0.25f);
            foreach (var button in _buttons)
                button.Lit = false;
            await Await.Seconds(0.25f);
        }
    }

    private void SpawnButtons()
    {
        var width = _buttonSpacing * _buttons.Length;
        var left = transform.position + Vector3.left * width * 0.5f;
        for (int i = 0; i < _buttons.Length; i++)
        {
            var pos = left + Vector3.right * _buttonSpacing * i;
            var button = Instantiate(_buttonPrefab);
            button.transform.position = pos;
            button.Color = _colors[i];
            button.TonePlayer.Frequency = _frequencies[i];
            _buttons[i] = button;
        }
    }
}
