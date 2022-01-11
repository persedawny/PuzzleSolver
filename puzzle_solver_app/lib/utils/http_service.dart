import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:puzzle_solver_app/constants/constants.dart';

class HttpService {
  final String baseUrl = Constants.baseUrl;

  Future<dynamic> get(String path,
      {Map<String, String> headers = const {}}) async {
    final response =
        await http.get(Uri.parse('$baseUrl$path'), headers: headers);
    return _handleResponse(response);
  }

  Future<dynamic> post(String path,
      {Map<String, String> headers = const {}, body}) async {
    final response = await http.post(Uri.parse('$baseUrl$path'),
        headers: headers, body: body);
    return _handleResponse(response);
  }

  dynamic _handleResponse(http.Response response) {
    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Failed to fetch');
    }
  }
}
