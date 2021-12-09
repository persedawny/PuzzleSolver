import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/about/about_controller.dart';

class AboutView extends StatelessWidget {
  const AboutView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MomentumBuilder(
      controllers: const [AboutController],
      builder: (context, snapshot) {
        return Scaffold(
          appBar: AppBar(
            title: const Text("About us"),
          ),
        );
      },
    );
  }
}
