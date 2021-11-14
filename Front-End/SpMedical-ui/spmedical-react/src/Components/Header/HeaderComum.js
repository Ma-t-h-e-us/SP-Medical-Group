import React, { Component } from "react";

//img:
import logo from '../../assets/img/logo.png'

class Header extends Component {
    render() {
        return (
            <section class="header">
                <div class="conteudoHeader container">
                    <img src={logo} alt="logo SpMedicalGroup"></img>
                    <nav class="navHeader">
                        <a href="">Consultas</a>
                        <a href="">Sair</a>
                    </nav>
                </div>
            </section>
        )
    }
}
export default Header