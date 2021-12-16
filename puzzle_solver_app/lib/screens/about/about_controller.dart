import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/about/about_model.dart';

class AboutController extends MomentumController<AboutModel> {
  @override
  AboutModel init() {
    return AboutModel(this);
  }
}
