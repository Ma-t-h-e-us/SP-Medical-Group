import React, { Component } from "react";

import logo from '../../assets/img/logo.png'

class HeaderAdm extends Component {
    render() {
        return (
            <header class="header">
                <div class="conteudoHeader container">
                    <img src={logo} alt="logo SpMedicalGroup"></img>
                    <nav class="navHeader">
                        <a href="">Consultas</a>
                        <a href="">Cadastrar consultas</a>
                        <a href="">Sair</a>
                    </nav>
                </div>
            </header>
        )
    }
}
export default HeaderAdm