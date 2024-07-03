import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:products/components/Home.dart';
import 'package:products/components/LoginPage.dart';
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
                ListTile(
                  title: Container(
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
                                userName ?? "Nome aqui",
                                style: const TextStyle(
                                  fontSize: 22,
                                  fontWeight: FontWeight.bold
                                ),
                              ),
                              Text(
                                userEmail ?? "Email aqui",
                                style: const TextStyle(
                                  fontSize: 14
                                ),
                              )
                            ],
                          )
                        ]),
                  ),
                  onTap: (){Navigator.of(context).pop();},
                ),
                ListTile(
                  title:  Container(
                    padding: const EdgeInsets.all(16),
                    child: const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Row(
                          children: <Widget>[
                            Icon(Icons.settings),
                            SizedBox(width: 16,),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                  Text(
                                    'Configuração',
                                    style: TextStyle(
                                      fontSize: 17
                                    ),
                                  ),
                                  Text(
                                    'Configurações do aplicatico',
                                    style: TextStyle(
                                      fontSize: 13
                                    ),
                                  )
                              ],
                            )
                          ],
                        )
                      ],
                    ),
                  ),
                  onTap: (){Navigator.of(context).pop();},
                ),
                 ListTile(
                  title:  Container(
                    padding: const EdgeInsets.all(16),
                    child: const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Row(
                          children: <Widget>[
                            Icon(Icons.credit_card),
                            SizedBox(width: 16,),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                  Text(
                                    'Forma de Pagamento',
                                    style: TextStyle(
                                      fontSize: 17
                                    ),
                                  ),
                                  Text(
                                    'Minhas formas de pagamento',
                                    style: TextStyle(
                                      fontSize: 13
                                    ),
                                  )
                              ],
                            )
                          ],
                        )
                      ],
                    ),
                  ),
                  onTap: (){Navigator.of(context).pop();},
                ),
                 ListTile(
                  title:  Container(
                    padding: const EdgeInsets.all(16),
                    child: const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Row(
                          children: <Widget>[
                            Icon(Icons.discount),
                            SizedBox(width: 16,),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                  Text(
                                    'Cupons',
                                    style: TextStyle(
                                      fontSize: 17
                                    ),
                                  ),
                                  Text(
                                    'Meus cupons de desconto',
                                    style: TextStyle(
                                      fontSize: 13
                                    ),
                                  )
                              ],
                            )
                          ],
                        )
                      ],
                    ),
                  ),
                  onTap: (){Navigator.of(context).pop();},
                ),
                 ListTile(
                  title:  Container(
                    padding: const EdgeInsets.all(16),
                    child: const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Row(
                          children: <Widget>[
                            Icon(Icons.favorite),
                            SizedBox(width: 16,),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                  Text(
                                    'Favoritos',
                                    style: TextStyle(
                                      fontSize: 17
                                    ),
                                  ),
                                  Text(
                                    'Meus produtos favoritos',
                                    style: TextStyle(
                                      fontSize: 13
                                    ),
                                  )
                              ],
                            )
                          ],
                        )
                      ],
                    ),
                  ),
                  onTap: (){Navigator.of(context).pop();},
                ),
                 ListTile(
                  title:  Container(
                    padding: const EdgeInsets.all(16),
                    child: const Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Row(
                          children: <Widget>[
                            Icon(Icons.logout),
                            SizedBox(width: 16,),
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                  Text(
                                    'Sair da conta',
                                    style: TextStyle(
                                      fontSize: 17
                                    ),
                                  ),
                                  Text(
                                    'Sair da minha conta',
                                    style: TextStyle(
                                      fontSize: 13
                                    ),
                                  )
                              ],
                            )
                          ],
                        )
                      ],
                    ),
                  ),
                  onTap: (){
                    if(mounted){
                       Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => const LoginPage())
                    );
                    }
                  },
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