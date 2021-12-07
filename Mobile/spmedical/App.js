/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow strict-local
 */

 import 'react-native-gesture-handler';

 import React from 'react';
 import { StatusBar } from 'react-native';
 
 import {NavigationContainer} from '@react-navigation/native';
 import {createStackNavigator} from '@react-navigation/stack';
 
 const AuthStack = createStackNavigator();
 
 import Login from './src/screens/login';
 
 export default function Stack() {
   return (
     <NavigationContainer>
       <StatusBar
         hidden={true}
       />
 
       <AuthStack.Navigator
         initialRouteName="Login"
         screenOptions={{
           headerShown: false,
         }}>
         <AuthStack.Screen name="Login" component={Login} />
       </AuthStack.Navigator>
     </NavigationContainer>
   );
 }