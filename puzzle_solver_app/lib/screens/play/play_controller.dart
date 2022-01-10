import 'package:flutter/material.dart';
import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/play/play_model.dart';

class PlayController extends MomentumController<PlayModel> {
  @override
  PlayModel init() {
    return PlayModel(this);
  }

  navigate(BuildContext context, {required Widget view}) {
    Navigator.of(context)
        .push(MaterialPageRoute(builder: (BuildContext context) => view));
  }
}
