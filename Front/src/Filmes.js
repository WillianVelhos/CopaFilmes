import React, { Component } from 'react';
import $ from 'jquery';
import PubSub from 'pubsub-js';
import { browserHistory } from 'react-router';

class PainelListagem extends Component {
    constructor() {
        super();

        this.state = { quantidadeFilmes: 0 }
    }

    componentDidMount() {
        PubSub.subscribe('atualiza-lista-filmesSelecionados', function (topico, novaLista) {
            this.setState({ quantidadeFilmes: novaLista.length });
        }.bind(this));
    }

    render() {
        return (
            <div className="jumbotron jumbotron-fluid">
                <div className="container">
                    <h1 className="display-4">Fase de Seleção</h1>
                    <p className="lead">Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão de Gerar Meu campeonato para prosseguir.</p>
                    <p className="lead"><b>Selecionado {this.state.quantidadeFilmes} de 8 filmes</b></p>
                </div>
            </div>
        );
    }
}

class ListagemFilmes extends Component {

    constructor() {
        super();
        this.state = { filmesSelectionados: [], filmes: [] }
    }

    habilitarDesabilitarChekedBox() {
        if (this.state.filmesSelectionados.length < 8) {
            for (var key in this.refs) {
                let value = this.refs[key];
                value.disabled = false;
            }
        } else {
            for (var key in this.refs) {
                let value = this.refs[key];
                if (!value.checked) {
                    value.disabled = true;
                }
            }
        }
    }

    adicionarRomoverFilmes(filmeSelecionado) {
        var filme = this.state.filmesSelectionados.find(element => element.id === filmeSelecionado.id);

        if (filme === undefined)
            this.state.filmesSelectionados.push(filmeSelecionado);
        else
            this.state.filmesSelectionados = this.state.filmesSelectionados.filter(function (filme) {
                return filme.id !== filmeSelecionado.id
            });

        PubSub.publish('atualiza-lista-filmesSelecionados', this.state.filmesSelectionados);
        this.habilitarDesabilitarChekedBox();
    }

    componentDidMount() {
        $.ajax({
            url: "https://localhost:44339/filme",
            dataType: 'json',
            success: function (resposta) {
                this.setState({ filmes: resposta.data });
            }.bind(this)
        });
    }

    render() {
        return (
            <div className="row">
                {
                    this.state.filmes.map(function (filme) {
                        return (
                            <div className="card col-3" style={{ width: '18rem' }}>
                                <div className="card-body">
                                    <div className="form-check">
                                        <input className="form-check-input" ref={filme.id} type="checkbox" onChange={this.adicionarRomoverFilmes.bind(this, filme)} id={filme.id} />
                                        <label className="form-check-label" htmlFor={filme.id}>
                                            <h5 className="card-title">{filme.titulo}</h5>
                                            <h3 className="card-title">{filme.ano}</h3>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        );
                    }, this)
                }
            </div>
        );
    }
}

class GerarCampeonato extends Component {

    constructor() {
        super();
        this.state = { filmesSelecionados: [], classButton: 'btn btn-primary disabled' }
        this.gerarCampeonato = this.gerarCampeonato.bind(this);
        this.habilitarDesabilitarBotao = this.habilitarDesabilitarBotao.bind(this)
    }

    componentWillMount() {
        PubSub.subscribe('atualiza-lista-filmesSelecionados', function (topico, novaLista) {
            this.setState({ filmesSelecionados: novaLista });
            this.habilitarDesabilitarBotao();
        }.bind(this));
    }

    habilitarDesabilitarBotao() {
        if (this.state.filmesSelecionados.length < 8) {
            this.setState({ classButton: 'btn btn-primary disabled' })
        } else {
            this.setState({ classButton: 'btn btn-primary ' })
        }
    }

    gerarCampeonato(evento) {
        evento.preventDefault();
        $.ajax({
            url: 'https://localhost:44339/Campeonato',
            contentType: 'application/json',
            dataType: 'json',
            type: 'post',
            data: JSON.stringify({ filmes: this.state.filmesSelecionados }),
            success: function (resposta) {
                browserHistory.push({ pathname: '/resultado', state: { resultado: resposta.data } })
            },
            error: function (resposta) {
                console.log(resposta)
            }
        });
    }

    render() {
        return (
            <div className="container-fluid" style={{ background: 'black' }}>
                <button type="button" ref={'button'} onClick={this.gerarCampeonato} className={this.state.classButton}>Gerar Meu Campeonato</button>
            </div>
        );
    }
}

export default class FilmesBox extends Component {

    render() {
        return (
            <div>
                <PainelListagem />
                <GerarCampeonato />
                <ListagemFilmes />
            </div>
        );
    }
}