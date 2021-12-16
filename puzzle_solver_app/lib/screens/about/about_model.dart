import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/about/about_controller.dart';

class AboutModel extends MomentumModel<AboutController> {
  const AboutModel(AboutController controller) : super(controller);

  @override
  void update() {
    AboutModel(controller).updateMomentum();
  }
}
