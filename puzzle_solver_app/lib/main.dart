import 'package:flutter/material.dart';
import 'package:puzzle_solver_app/enums/puzzle.dart';
import 'package:puzzle_solver_app/ui/screens/about.dart';
import 'package:puzzle_solver_app/ui/screens/play.dart';
import 'package:puzzle_solver_app/ui/screens/profile.dart';
import 'package:puzzle_solver_app/ui/screens/solve.dart';
import 'package:puzzle_solver_app/ui/utils/button.dart';

void main() {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const Home(),
    );
  }
}

class Home extends StatefulWidget {
  static Puzzle selectedPuzzle = Puzzle.sudoku;
  const Home({Key? key}) : super(key: key);

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("PuzleSolver"),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            DropdownButton(
              onChanged: (puzzle) {
                setState(() {
                  Home.selectedPuzzle = puzzle as Puzzle;
                });
              },
              value: Home.selectedPuzzle,
              items: const [
                DropdownMenuItem(
                  value: Puzzle.sudoku,
                  child: Text('Sudoku'),
                ),
                DropdownMenuItem(
                  value: Puzzle.other,
                  child: Text('Other'),
                ),
              ],
            ),
            if (Home.selectedPuzzle != Puzzle.other)
              Column(
                children: [
                  CustomButton(
                    label: "Play",
                    onPressed: () => navigate(
                      const Play(),
                    ),
                  ),
                  CustomButton(
                    label: "Solve",
                    onPressed: () => navigate(
                      const Solve(),
                    ),
                  ),
                  CustomButton(
                    label: "Profile",
                    onPressed: () => navigate(
                      const Profile(),
                    ),
                  ),
                  CustomButton(
                    label: "About",
                    onPressed: () => navigate(
                      const About(),
                    ),
                  ),
                ],
              ),
            if (Home.selectedPuzzle == Puzzle.other)
              const Text(
                  "Want to do any puzzles that are not implemented yet! Come help us :)"),
          ],
        ),
      ),
    );
  }

  navigate(Widget page) {
    Navigator.of(context).push(
        MaterialPageRoute(builder: (BuildContext context) => page));
  }
}
