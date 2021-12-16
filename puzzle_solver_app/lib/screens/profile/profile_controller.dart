import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/profile/profile_model.dart';

class ProfileController extends MomentumController<ProfileModel> {
  @override
  ProfileModel init() {
    return ProfileModel(this);
  }
}
