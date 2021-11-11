import React, { Component } from "react";

class Header extends Component {
    render() {
        return (
            <header class="header">
                <div class="conteudoHeader container">
                    <img src="../assets/logo.png" alt="logo SpMedicalGroup"></img>
                    <nav class="navHeader">
                        <a href="">Consultas</a>
                        <a href="">Sair</a>
                    </nav>
                </div>
            </header>
        )
    }
}
export default Header