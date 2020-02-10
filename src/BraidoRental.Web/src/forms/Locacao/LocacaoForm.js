import React, { useState, useEffect } from 'react'
import ToggleDisplay from 'react-toggle-display'
import * as api from '../../api/locacao';

const LocacaoForm = props => {

	const carro = props.currentCarro;
	const initialFormState = { idLocacao: null, idCliente: null, dataInicio: '', dataFim: '' }

	const [showTotal, setShowTotal] = useState(false);
	const [valorTotal, setValorTotal] = useState(0);
	const [locacao, setLocacao] = useState(initialFormState)

	const handleInputChange = event => {
		const { name, value } = event.target

		setLocacao({ ...locacao, [name]: value })
	}

	const simularAgendamento = (event) => {
		event.preventDefault()
		if (!carro.id || !locacao.dataInicio || !locacao.dataFim) return

		api.simularAgendamento(locacao, carro).then(data => {
			if (data.sucesso === true) {
				setValorTotal(data.objeto.valorTotal);
				setShowTotal(true);
			}
			else {
				alert('Data not Saved');
				debugger;
			}
		})
	}

	const realizarAgendamento = (event) => {
		event.preventDefault()
		if (!carro.id || !locacao.dataInicio || !locacao.dataFim) return

		api.realizarAgendamento(locacao, carro).then(data => {
			if (data.sucesso === true) {
				setValorTotal(data.objeto.valorTotal);
				setShowTotal(true);
			}
			else {
				alert('Data not Saved');
				debugger;
			}
		})
	}

	return (
		<form>
			<label>Marca</label>
			<input type="text" name="marca" value={carro.marca} disabled='disabled' />
			<label>Modelo</label>
			<input type="text" name="modelo" value={carro.modelo} disabled='disabled' />
			<label>Valor Diario</label>
			<input type="number" name="valorDiario" value={carro.valorDiario} disabled='disabled' />

			<label>Data Inicio</label>
			<input type="date" name="dataInicio" value={locacao.dataInicio} onChange={handleInputChange} />
			<label>Data Fim</label>
			<input type="date" name="dataFim" value={locacao.dataFim} onChange={handleInputChange} />
			<button onClick={simularAgendamento}>Simular Agendamento</button>
			<button onClick={realizarAgendamento}>Realizar Agendamento</button>
			<br />
			<ToggleDisplay show={showTotal}>
				<label>Valor Total</label>
				<input type="number" name="valorTotal" value={valorTotal} disabled='disabled' />
			</ToggleDisplay>
		</form>
	)
}

export default LocacaoForm
