class SudokuField {
  SudokuField({
    this.value,
    this.index,
    this.potentials = const [],
  });

  int? value;
  int? index;
  List<int> potentials;

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is SudokuField &&
          runtimeType == other.runtimeType &&
          value == other.value &&
          index == other.index;

  @override
  int get hashCode => index.hashCode;
}
