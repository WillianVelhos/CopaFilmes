import React, { Component } from 'react';
import { Link } from 'react-router';

export default class Resultado extends Component {
    constructor() {
        super();
    }

    render() {
        return (
            <div>
                <div className="jumbotron jumbotron-fluid">
                    <div className="container">
                        <h1 className="display-4">Resultado Final</h1>
                    </div>
                </div>
                <Link to="/" className="btn btn-primary" >Voltar para listagem</Link>
                <div className="row">
                    <div className="col-sm-4">
                        <div className="card">
                            <div className="card-body">
                                <h4 className="card-title">1º lugar</h4>
                                <h5 className="card-title">{this.props.location.state.resultado.vencedor.titulo}</h5>
                                <p className="card-text "> {this.props.location.state.resultado.vencedor.ano}</p> 
                            </div>
                        </div>
                    </div>
                    <div className="col-sm-4">
                        <div className="card">
                            <div className="card-body">
                            <h4 className="card-title">2º lugar</h4>
                                <h5 className="card-title">{this.props.location.state.resultado.derrotado.titulo}</h5>
                                <p className="card-text "> {this.props.location.state.resultado.derrotado.ano}</p> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}