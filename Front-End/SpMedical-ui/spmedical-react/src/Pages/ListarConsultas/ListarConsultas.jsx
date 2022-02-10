import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import { render } from '@testing-library/react';

//css:
import '../../assets/css/ListarConsultas.css';
import '../../assets/css/Footer.css';
import '../../assets/css/Header.css';

import botaoEditar from '../../assets/img/botao-editar.png';

//Componentes:
import HeaderComum from '../../Components/Header/HeaderComum'
import HeaderAdm from '../../Components/Header/HeaderAdm'
import Footer from '../../Components/Footer/footer'

export default function ListarConsultas() {
    const [listaConsultas, setListaConsultas] = useState([]);
    const [descricao, setDescricao] = useState('');
    const [idConsulta, setIdConsulta] = useState(0);
    const [idSituacao, setIdSituacao] = useState(0);
    const [editando, setEditando] = useState(false);
    const [editandoSituacao, setEditandoSituacao] = useState(false);


    function listarConsultas() {

       
            axios('https://620558c3161670001741b96a.mockapi.io/consulta', {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
                .then(resposta => {
                    if (resposta.status === 200) {
                        console.log(resposta.data);
                        setListaConsultas(resposta.data);
                        console.log(listaConsultas);
                    }
                })

                .catch(erro => console.log(erro))

    };

    function editarConsulta() {
        axios.patch('http://localhost:5000/api/Consultas/Descricao/' + idConsulta, { descricao: descricao },
            {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('Atualizado')
                    setEditando(false);
                    listarConsultas();
                }
            })
            .catch(
                setEditando(false),
                console.log("Deu erro na descricao"))
    }

    function editarSituacao(Consulta) {
        setIdConsulta(Consulta.idConsulta);
        setEditandoSituacao(true);
        console.log(localStorage.getItem('usuario-login'));
        axios.patch('http://localhost:5000/api/Consultas/Cancelar/' + idConsulta,
            {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log('Situação alterada');
                    setEditandoSituacao(false);
                    listarConsultas();
                }
            })
            .catch(
                setEditandoSituacao(false),
                console.log("Erro situação")
            );
    }

    function buscarConsulta(Consulta) {
        setIdConsulta(Consulta.idConsulta);
        setDescricao(Consulta.descricao);
        setEditando(true);
        console.log("consulta buscada")
    }

    function renderSwitch(param) {
        switch (param) {
            case 1:
                return <p style={{ color: '#02D66D', fontWeight: 'bold' }} >Realizada</p>
            case 2:
                return <span style={{ color: 'red' }}>Cancelada</span>
            case 3:
                return <span style={{ color: 'blue' }}>Ajendada</span>
            default:
                return <span>Status desconhecido</span>
        }
    }

    useEffect(listarConsultas, []);

    return (
        <div>
            <HeaderComum />
            <main className="main_ListarConsultas">
                <section className="consultas_ListarConsultas">
                    <div className="tituloConsultas_ListarConsultas">
                        <h1>Consultas</h1>
                        <hr></hr>
                    </div>
                    <div className="areaConsultas_ListarConsultas">
                        {listaConsultas.map((consulta) => {
                            return (
                                <div key={consulta.idConsulta}>
                                    <div className="cadaConsulta_ListarConsultas">
                                        <div className="span_ListarConsultas">
                                            <span>Médico:</span>
                                            <p key={consulta.idConsulta}>{consulta.idMedico.nome}</p>
                                        </div>
                                        <div className="span_ListarConsultas">
                                            <span>Paciente:</span>
                                            <p key={consulta.idConsulta}>{consulta.idPaciente.nomePaciente}</p>
                                        </div>
                                        <div className="span_ListarConsultas">
                                            <span key={consulta.idConsulta}>{consulta.dataConsulta}</span>
                                        </div>
                                        <div style={{ width: 160 }} className="span_ListarConsultas">
                                            {consulta.descricao == '' ? editando == true && idConsulta == consulta.idConsulta ? <input type="text" value={descricao} onChange={(campo) => setDescricao(campo.target.value)} name="descricao" placeholder="Descrição"></input> : <span style={{ color: 'red', opacity: 0.6 }}>Sem descricao</span> : editando == true && idConsulta == consulta.idConsulta ? <input type="text" value={descricao} onChange={(campo) => setDescricao(campo.target.value)} name="descricao" placeholder="Descrição"></input> : <span>{consulta.descricao}</span>}
                                            {usuarioAutenticado() && parseJwt().role == '2' ? editando == true && idConsulta == consulta.idConsulta ? <button onClick={editarConsulta}>Concluir</button> : <button onClick={() => buscarConsulta(consulta)} style={{ borderColor: 'transparent', backgroundColor: 'transparent' }}><img src={botaoEditar} style={{ width: 28 }} alt="Editar consulta" /></button> : null}
                                        </div>
                                        <div className="span_ListarConsultas">
                                            {renderSwitch(consulta.idSituacao)}
                                            {parseJwt().role == '1' && consulta.idSituacao != 1 ? <button onClick={() => editarSituacao(consulta)} style={{ borderColor: 'transparent', backgroundColor: 'transparent' }}><img src={botaoEditar} style={{ width: 28 }} alt="Editar consulta" /></button> : null}
                                        </div>
                                    </div>
                                </div>
                            )
                        })}
                    </div>
                </section>
            </main>
            <Footer />
        </div>
    );
}
