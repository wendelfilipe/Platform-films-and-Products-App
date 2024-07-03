import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:products/components/Home.dart';
import 'package:products/components/Notifications.dart';
import 'package:products/components/ProductsPage.dart';
import 'package:products/main.dart';
import 'package:http/http.dart' as http;

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  int _selectedIndex = 0;

  dynamic userEmail;
  dynamic userName;
  dynamic userPhoto;

  @override
  void initState(){
    super.initState();
    _awaitMethods();
  }

  void _awaitMethods() async {
    await _getUser();
  }


  Future<void> _getUser() async {
    const url = 'https://api-keywayflutter.azurewebsites.net/api/services/app/Session/GetCurrentLoginInformations';
    final response = await http.get(Uri.parse(url));

    if(response.statusCode == 200)
    {
      var bory = jsonDecode(response.body);
      var result = bory['result'];

      var user = bory['user'];
    }
  }

  void _onItemTapped(int index){
    setState(() {
      _selectedIndex = index;
    });
  }

  static const List<Widget> _widgetOptions = <Widget>[
    Home(),
    ProductsPage(),
    Notifications()


  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Center(
          child: Text(
            'Tela incial'
          ),
        ),
      leading: Builder(
        builder: (context) {
          return IconButton(
            icon: const Icon(Icons.menu),
            onPressed: () {
              Scaffold.of(context).openDrawer();
            },
          );
        }
      ),
      ),
      drawer: Drawer(
        child: Container(
          color: Colors.white,
          child: SafeArea(
            child: ListView(
              padding: EdgeInsets.zero,
              children: <Widget>[
                Container(
                  padding: const EdgeInsets.all(16),
                  child: const Text(
                    'Menu',
                    style: TextStyle(
                      fontSize: 20
                    ),
                  ),
                ),
                Container(
                    color: Colors.white,
                    padding: const EdgeInsets.all(16),
                    child: Row(
                      children: [
                        const CircleAvatar(
                          backgroundImage: AssetImage('lib/assets/images/bill.jpeg'),
                          radius: 30
                        ),
                        const SizedBox(width: 16),
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            Text(
                              userName ?? "",
                              style: const TextStyle(
                                fontSize: 18,
                                fontWeight: FontWeight.bold
                              ),
                            ),
                            Text(
                              userEmail ?? "",
                              style: const TextStyle(
                                fontSize: 14
                              ),
                            )
                          ],
                        )
                      ]),
                ),
                ListTile(
                  leading: const Icon(Icons.settings),
                  title: const Text('Configuração'),
                  onTap: () {Navigator.pop(context);},
                ),
              ],
            ),
          ),
        ),
      ),
      body: Center(
        child: IndexedStack(
          index: _selectedIndex,
          children: _widgetOptions,
        ),
      ),
      bottomNavigationBar: BottomNavigationBar(
        selectedItemColor: Colors.blue,
        unselectedItemColor: Colors.black,
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
            activeIcon: Icon(Icons.home, color: Colors.blue,)
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.list),
            label: 'Podutos',
            activeIcon: Icon(Icons.list, color: Colors.blue,)
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.notifications),
            label: 'Notificações',
            activeIcon: Icon(Icons.notifications, color: Colors.blue,)
          )
        ],
        currentIndex: _selectedIndex,
        onTap: _onItemTapped,
      ),
    );
  }
}