import 'package:momentum/momentum.dart';
import 'package:puzzle_solver_app/screens/profile/profile_controller.dart';

class ProfileModel extends MomentumModel<ProfileController> {
  const ProfileModel(ProfileController controller) : super(controller);

  @override
  void update() {
    ProfileModel(controller).updateMomentum();
  }
}
