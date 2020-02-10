import React, { useState, useEffect } from 'react'
import * as api from '../../api/cliente';

const EditClienteForm = props => {
  const [ cliente, setCliente ] = useState(props.currentCliente)

  useEffect(
    () => {
      setCliente(cliente)
    }
  )
  // You can tell React to skip applying an effect if certain values haven’t changed between re-renders. [ props ]

  const handleInputChange = event => {
    const { name, value } = event.target

    setCliente({ ...cliente, [name]: value })
  }

  return (
    <form
      onSubmit={event => {
        event.preventDefault()

        api.addCliente(cliente).then(data => {
					if (data.sucesso === true) {
						props.updateCliente(data.objeto);
					}
					else {
						alert('Data not Saved');
						debugger;
					}
				})
      }}
    >
      <label>Nome</label>
			<input type="text" name="nome" value={cliente.nome} onChange={handleInputChange} />
			<label>Email</label>
			<input type="text" name="email" value={cliente.email} onChange={handleInputChange} />
			<label>CPF</label>
			<input type="text" name="cpf" value={cliente.cpf} onChange={handleInputChange} />
    
      <button>Atualizar</button>
      <button onClick={() => props.setEditing(false)} className="button muted-button">
        Cancel
      </button>
    </form>
  )
}

export default EditClienteForm
