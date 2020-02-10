import React from 'react'

const ClienteTable = props => (
  <table>
    <thead>
      <tr>
        <th>Nome</th>
        <th>Email</th>
        <th>CPF</th>
        <th>Ações</th>
      </tr>
    </thead>
    <tbody>
      {props.clientes.length > 0 ? (
        props.clientes.map(cliente => (
          <tr key={cliente.id}>
            <td>{cliente.nome}</td>
            <td>{cliente.email}</td>
            <td>{cliente.cpf}</td>
            <td>
              <button
                onClick={() => {
                  props.editRow(cliente)
                }}
                className="button muted-button"
              >
                Alterar
              </button>
            </td>
          </tr>
        ))
      ) : (
        <tr>
          <td colSpan={4}>Sem Dados de Clientes</td>
        </tr>
      )}
    </tbody>
  </table>
)

export default ClienteTable
