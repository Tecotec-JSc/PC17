using Xunit;

// UI tests drive real mouse/keyboard input on one desktop session - two test classes
// running at once would fight over the same cursor. xUnit parallelizes across test
// collections (effectively, across classes) by default; this puts everything in this
// assembly into a single implicit collection so all UI tests run one at a time,
// regardless of how many [Fact]/test classes get added under Tests/.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
