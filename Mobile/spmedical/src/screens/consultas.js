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
import { format } from "date-fns";

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
        const token = await AsyncStorage.getItem('userToken')
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
            <View style={styles.conteudo}>
                <Text style={styles.tituloConsultas}>Consultas</Text>
                <FlatList
                    data={this.state.listaConsultas}
                    keyExtractor={item => item.idConsulta}
                    renderItem={this.renderItem}
                // style={styles.flatList}
                />
            </View>

        )
    }

    renderSwitch(param) {
        switch (param) {
            case 1:
                return <Text style={styles.realizada}>Realizada</Text>;
            case 2:
                return <Text style={styles.semDescricao}>Cancelada</Text>;
            case 1:
                return <Text style={styles.ajendada}>Ajendada</Text>;
            default:
                return <Text style={styles.semDescricao}>Situação desconhecida</Text>;
        }
    }

    renderItem = ({ item }) => (
        <View style={styles.cadaConsulta}>

            <Text style={styles.texto}>Data : {format(item.dataConsulta, "dd-MM-YYYY")}</Text>
            <Text>Situação : {this.renderSwitch(item.idSituacao)}</Text>


            <Text>Médico : {(item.idMedicoNavigation.nome)}</Text>
            <Text>Paciente : {(item.idPacienteNavigation.nomePaciente)}</Text>
            {
                item.descricao != null ? <Text style={styles.semDescricao}>Sem Descrição</Text> : <Text>{item.descricao}</Text>
            }

        </View>
    )
}

const styles = StyleSheet.create({
    conteudo: {
        alignItems: 'center',
        justifyContent: 'center',
    },
    tituloConsultas: {
        fontSize: 48,
        fontWeight: 'bold',
        color: '#05F2DB',
        marginTop: 20,
        marginBottom: 20,
    },
    flatList: {
        width: 400
    },
    cadaConsulta: {
        width: 270,
        height: 120,
        marginBottom: 10,
        marginTop: 10,
        borderBottomColor: '#05F2DB',
        borderBottomWidth: 3,
        justifyContent: 'space-evenly',
    },
    semDescricao: {
        color: 'red',
        opacity: 0.6,
        marginBottom: 20
    },
    realizada: {
        color: 'green',
    },
    ajendada: {
        color: 'blue',
    },
})