import React from 'react'
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom'; 
import Cliente from './components/Cliente'
import Carro from './components/Carro'
import Locacao from './components/Locacao'
import Faturamento from './components/Faturamento'

const App = () => {
	return (

		<Router>  
			<br />
			<div className="menu">  
				<button type="button">  
					<Link to={'/Locacao'} className="nav-link">Locação de Carros</Link>  
				</button>  
				<button type="button">   
					<Link to={'/Carro'} className="nav-link">Cadastro de Carros</Link>  
				</button> 
				<button type="button">  
					<Link to={'/Cliente'} className="nav-link">Cadastro de Clientes</Link>  
				</button>
				<button type="button">  
					<Link to={'/Faturamento'} className="nav-link">Relatorio de Faturamento</Link>  
				</button>  
			</div>
			<Switch>  
				<Route exact path='/Carro' component={Carro} />  
				<Route exact path='/Cliente' component={Cliente} />  
				<Route exact path='/Faturamento' component={Faturamento} />    
				<Route path='/' component={Locacao} />
			</Switch>  
		</Router>  
	)
}

export default App
