import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'roberto.possarle@spmedicalgroup.com.br',
            senha: '123456',
        };
    }

    realizarLogin = async () => {

        const resposta = await api.post('/Login', {
            email: this.state.email,
            senha: this.state.senha,
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            console.warn(token);
            this.props.navigation.navigate('Consultas');
        }



    };

    render() {
        return (
            <ImageBackground
                source={require('../../assets/img/fundoLogin.png')}
                style={StyleSheet.absoluteFillObject}
            >
                <View>
                    {/* <Image
                    source={require('')}
                /> */}
                    <TextInput
                        placeholder="Email"
                        onChangeText={email => this.setState({ email })}
                        style={styles.input}
                    />
                    <TextInput
                        placeholder="Senha"
                        onChangeText={senha => this.setState({ senha })}
                        style={styles.input}
                    />
                    <TouchableOpacity
                        onPress={this.realizarLogin}
                        style={styles.btnLogin}
                    >
                        <Text style={styles.btnLoginText}>Login</Text>
                    </TouchableOpacity>
                </View>
            </ImageBackground>
        )
    };
}
const styles = StyleSheet.create({
    overlay: {
        ...StyleSheet.absoluteFillObject
      },
    input : {
        width : 230,
        height : 45,
        fontSize : 24,
        borderRadius: 15,
        color: '#FFF',
        backgroundColor : '#FFF',
    },
    btnLogin : {
        width : 200,
        height : 45,
        backgroundColor : '#048ABF',
        borderRadius: 15,
        alignItems : 'center',
        justifyContent : 'center',
    },
    btnLoginText : {
        color : '#FFF',
        fontSize : 30,
        fontFamily : 'Open Sans',
    }
});
