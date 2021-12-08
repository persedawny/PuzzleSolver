import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/models/field.dart';

class SudokField extends StatefulWidget {
  const SudokField({
    Key? key,
    required this.field,
    required this.onPressed,
    required this.selected,
  }) : super(key: key);

  final Field field;
  final Function(int) onPressed;
  final int? selected;

  @override
  _SudokFieldState createState() => _SudokFieldState();
}

class _SudokFieldState extends State<SudokField> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        widget.onPressed(widget.field.index);
      },
      child: Container(
        height: 20,
        width: 20,
        decoration: BoxDecoration(
          border: Border.all(
            width: widget.selected == widget.field.index ? 5 : 1,
            color: widget.selected == widget.field.index
                ? Colors.red
                : Colors.black,
          ),
        ),
        padding: const EdgeInsets.all(5),
        child: Center(
          child: Text(
            widget.field.value != null ? widget.field.value.toString() : '',
          ),
        ),
      ),
    );
  }
}
