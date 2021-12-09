import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/profile/profile_controller.dart';

class ProfileView extends StatelessWidget {
  const ProfileView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MomentumBuilder(
      controllers: const [ProfileController],
      builder: (context, snapshot) {
        return Scaffold(
          appBar: AppBar(
            title: const Text("Profile"),
          ),
        );
      },
    );
  }
}
