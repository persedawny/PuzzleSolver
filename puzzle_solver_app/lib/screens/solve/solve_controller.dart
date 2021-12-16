import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/solve/solve_model.dart';

class SolveController extends MomentumController<SolveModel> {
  @override
  SolveModel init() {
    return SolveModel(this);
  }
}
