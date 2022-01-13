// Mocks generated by Mockito 5.0.17 from annotations
// in puzzle_solver_app/test/sudoku_repository_test.dart.
// Do not manually edit this file.

import 'dart:async' as _i3;

import 'package:mockito/mockito.dart' as _i1;
import 'package:puzzle_solver_app/services/http_service.dart' as _i2;

// ignore_for_file: avoid_redundant_argument_values
// ignore_for_file: avoid_setters_without_getters
// ignore_for_file: comment_references
// ignore_for_file: implementation_imports
// ignore_for_file: invalid_use_of_visible_for_testing_member
// ignore_for_file: prefer_const_constructors
// ignore_for_file: unnecessary_parenthesis
// ignore_for_file: camel_case_types

/// A class which mocks [HttpService].
///
/// See the documentation for Mockito's code generation for more information.
class MockHttpService extends _i1.Mock implements _i2.HttpService {
  MockHttpService() {
    _i1.throwOnMissingStub(this);
  }

  @override
  String get baseUrl =>
      (super.noSuchMethod(Invocation.getter(#baseUrl), returnValue: '')
          as String);
  @override
  _i3.Future<dynamic> get(String? path,
          {Map<String, String>? headers = const {}}) =>
      (super.noSuchMethod(Invocation.method(#get, [path], {#headers: headers}),
          returnValue: Future<dynamic>.value()) as _i3.Future<dynamic>);
  @override
  _i3.Future<dynamic> post(String? path,
          {Map<String, String>? headers = const {},
          dynamic body,
          bool? shouldReturnBody = true}) =>
      (super.noSuchMethod(
          Invocation.method(#post, [
            path
          ], {
            #headers: headers,
            #body: body,
            #shouldReturnBody: shouldReturnBody
          }),
          returnValue: Future<dynamic>.value()) as _i3.Future<dynamic>);
}
