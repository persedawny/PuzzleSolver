import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/solve/solve_controller.dart';

class SolveModel extends MomentumModel<SolveController> {
  const SolveModel(SolveController controller) : super(controller);

  @override
  void update() {
    SolveModel(controller).updateMomentum();
  }
}
