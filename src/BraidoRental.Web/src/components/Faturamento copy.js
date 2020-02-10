import React, { useState, useEffect, Fragment } from 'react'
import AddCarroForm from '../forms/Carro/AddCarroForm'
import EditCarroForm from '../forms/Carro/EditCarroForm'
import FaturamentoTable from '../tables/FaturamentoTable'
import * as api from '../api/faturamento'

const Faturamento = () => {

	useEffect(() => {
		(async () => {
			let res = await api.relatorioFaturamentoPorCarro()
			setRel(res.objeto);
		})();
	});

	// Data
	const relData = []

	// Setting state
	const [rel, setRel] = useState(relData)

	return (
		<div className="container">
			<h1>Cadastro de Carros</h1>
			<div className="flex-row">
				<div className="flex-large">
					<h2>Visualizar Carro</h2>
					<FaturamentoTable rel={rel} />
				</div>
			</div>
		</div>
	)
}

export default Faturamento
