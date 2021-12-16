import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/play/play_controller.dart';

class PlayModel extends MomentumModel<PlayController> {
  const PlayModel(PlayController controller) : super(controller);

  @override
  void update() {
    PlayModel(controller).updateMomentum();
  }
}
