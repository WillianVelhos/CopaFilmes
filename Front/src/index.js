import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import FilmesBox from './Filmes';
import Resultado from './Resultado';
import { Router, Route, browserHistory, IndexRoute } from 'react-router';

ReactDOM.render(
    (<Router history={browserHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={FilmesBox} />
            <Route path="/resultado" component={Resultado} />
        </Route>
    </Router>),
    document.getElementById('root')
);

serviceWorker.unregister();
