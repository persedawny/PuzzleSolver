class SudokuField {
  SudokuField({this.value, this.index});

  int? value;
  int? index;

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
