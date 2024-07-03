import 'package:flutter/material.dart';
import 'package:products/components/LoginPage.dart';

main() => runApp(const Products());

class Products extends StatelessWidget {
  const Products({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      home: LoginPage()
    );
  }
}