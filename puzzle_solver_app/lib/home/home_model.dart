import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/enums/puzzle_enum.dart';
import 'package:puzzle_solver_app/home/home_controller.dart';

class HomeModel extends MomentumModel<HomeController> {
  const HomeModel(
    HomeController controller, {
    required this.puzzle,
  }) : super(controller);

  final PuzzleType puzzle;

  @override
  void update({
    PuzzleType? puzzle,
  }) {
    HomeModel(
      controller,
      puzzle: puzzle ?? this.puzzle,
    ).updateMomentum();
  }
}
