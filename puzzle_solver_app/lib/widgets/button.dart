import 'package:flutter/material.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({
    Key? key,
    required this.label,
    required this.onPressed,
    this.width = 200,
    this.height = 50,
    this.color = Colors.blue,
  }) : super(key: key);

  final Function onPressed;
  final String label;
  final double height;
  final double width;
  final Color color;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 5, right: 10, left: 10),
      child: SizedBox(
        height: height,
        width: width,
        child: ElevatedButton(
          style: ElevatedButton.styleFrom(primary: color),
          onPressed: () {
            onPressed.call();
          },
          child: Text(label),
        ),
      ),
    );
  }
}
