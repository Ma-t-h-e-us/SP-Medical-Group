import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
    FlatList,
    SafeAreaView,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: []
        };
    }

    buscarConsultas = async () => {
        const token = await  AsyncStorage.getItem('userToken')
        const resposta = await api.get('Consultas/Listar/Minhas'
            , {
                headers: {
                    'Authorization': 'Bearer ' + token
                },
            });

        if (resposta.status == 200) {
            const dadosDaApi = resposta.data.listaConsultas;
            this.setState({ listaConsultas: dadosDaApi });
            console.warn(this.state.listaConsultas);
        }

    };

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <View style={styles.a}>
                <Text>CONSULTAS</Text>
                <FlatList
                    data={this.state.listaConsultas}
                    keyExtractor={item => item.idConsulta}
                    renderItem={this.renderItem}
                />
            </View>

        )
    }

    renderItem = ({ item }) => (
        <View style = {styles.a}>
            <View>
                <Text>{(item.dataConsulta)}</Text>
                <Text>{(item.idSituacao)}</Text>
            </View>
            <View>
                <Text>{(item.idMedicoNavigation.nome)}</Text>
                <Text>{(item.idPacienteNavigation.nomePaciente)}</Text>
                <Text>{item.descricao}</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    a: {
        flex: 1,
    }
})