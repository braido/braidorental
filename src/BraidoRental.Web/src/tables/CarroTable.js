import React from 'react'

const CarroTable = props => (
  <table>
    <thead>
      <tr>
        <th>Marca</th>
        <th>Modelo</th>
        <th>Placa</th>
        <th>Valor Diario</th>
        <th>Ações</th>
      </tr>
    </thead>
    <tbody>
      {props.carros.length > 0 ? (
        props.carros.map(carro => (
          <tr key={carro.id}>
            <td>{carro.marca}</td>
            <td>{carro.modelo}</td>
            <td>{carro.placa}</td>
            <td>{carro.valorDiario}</td>
            <td>
              <button
                onClick={() => {
                  props.editRow(carro)
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
          <td colSpan={5}>Sem Dados de Carros</td>
        </tr>
      )}
    </tbody>
  </table>
)

export default CarroTable
