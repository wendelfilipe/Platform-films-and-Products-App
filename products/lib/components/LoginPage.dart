import 'dart:convert';

import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:products/components/HomePage.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {

  final _formKey = GlobalKey<FormState>();
  final TextEditingController _userController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();

  Future<void> _login(BuildContext context, String user, String userPassword) async {

    var url = "https://api-keywayflutter.azurewebsites.net/api/TokenAuth/Authenticate";

    var userAuthenticate = { 
      "userNameOrEmailAddress": user,
      "password": userPassword,
      "rememberClient": true 
      };

    final response = await http.post(
      Uri.parse(url),
      body: jsonEncode(userAuthenticate),
      headers: <String, String>{
        "content-Type": "application/json; charset=UTF-8"
      }
    ); 
    var data = jsonDecode(response.body);

    //Dialog when user forget your password
    void forgotPassword() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Esqueceu sua senha'),
          content: TextField (
            controller: _emailController,
            decoration: const InputDecoration(
              labelText: 'Email',
              border: OutlineInputBorder(
                borderSide: BorderSide(
                  color: Colors.blue
                )
              )
            ),
          ),
          actions: <Widget>[
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blue[700],
                  foregroundColor: Colors.white
                ),
                child: const Text('ok')
              ),
            ),
          ],
        );
      },
    );
  }
    //Dialog when email or password is wrong
    void showAlertDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          backgroundColor: Colors.white,
          title: const Text('Dados de Acesso incorretos'),
          content: RichText(
            text: TextSpan(
              children: [
               const  TextSpan(
                  text: 'Os dados de acesso não estão corretos. Caso não esteja conseguindo acessar sua conta, selecione a opção ',
                  style: TextStyle(
                    color: Colors.black
                  ),
                ),
                TextSpan(
                  text: 'Esqueci minha senha',
                  style: const TextStyle(
                    color: Colors.black,
                    fontWeight: FontWeight.bold
                  ),
                  recognizer: TapGestureRecognizer()
                    ..onTap = () {
                      Navigator.of(context).pop();
                      forgotPassword();
                    },
                ),
                const TextSpan(
                  text: '.',
                  style: TextStyle(color: Colors.black),
                ),
              ],
            ),
          ),
          actions: <Widget>[
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.blue[700],
                  foregroundColor: Colors.white
                ),
                child: const Text('Preecher dados novamente'),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
            ),
          ],
        );
      },
    );
  }

      if(response.statusCode == 200)
      {
        if(mounted){
          Navigator.push(
            context, 
            MaterialPageRoute(builder: (context) => const HomePage())
          );
        }
      }
      else
      {
        showAlertDialog();
      }

  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Center(
          child: Text('Dunder Mifflin'),
        ),
        backgroundColor: Colors.blue[300],
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              TextFormField(
                controller: _userController,
                decoration: const InputDecoration(
                  labelText: 'Email',
                  border: OutlineInputBorder(
                    borderSide: BorderSide(
                      color: Colors.blue
                    )
                  ),
                ),
                validator: (value) {
                  if(value == null || value.isEmpty){
                    return 'Campo obrigatório';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16),
              TextFormField(
                controller: _passwordController,
                decoration: const InputDecoration(
                  labelText: 'Password',
                  border: OutlineInputBorder(
                    borderSide: BorderSide(
                      color: Colors.blue
                    ),
                  ),
                ),
                obscureText: true,
                validator: (value) {
                  if(value == null || value.isEmpty){
                    return 'Campo obrigatório';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () async {
                    String user = _userController.text;
                    String password = _passwordController.text;

                    if(_formKey.currentState?.validate() ?? false){
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(content: Text('Processing')),
                      );
                    }
                          
                    try{
                      await _login(context, user, password);
                    } catch (e){
                      print('Error: $e');
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.blue[700],
                    foregroundColor: Colors.white
                  ),
                  child: const Text(
                    'Acessar'),
                ),
              )
            ],
          ),
        ),
      )
    );
  }
}