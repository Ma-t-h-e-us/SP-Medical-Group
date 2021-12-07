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
            email: '',
            senha: '',
        };
    }

    realizarLogin = async () => {

        console.warn(this.state.email + ' ' + this.state.senha);

        const resposta = await api.post('/Login', {
            email: this.state.email,
            senha: this.state.senha,
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            this.props.navigation.navigate('Consultas');
        }

        console.warn(token);

    };

    render() {
        return (
            <View>
                {/* <Image
                    source={require('')}
                /> */}
                <TextInput
                    placeholder="Email"
                    onChangeText={email => this.setState({ email })}
                />
                <TextInput
                    placeholder="Senha"
                    onChangeText={senha => this.setState({ senha })}
                />
                <TouchableOpacity>
                    <Text>Login</Text>
                </TouchableOpacity>
            </View>
        )
    };
}