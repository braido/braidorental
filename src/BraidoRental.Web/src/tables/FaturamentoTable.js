import React from 'react'

const FaturamentoTable = props => (
  <table>
    <thead>
      <tr>
        <th>Marca</th>
        <th>Modelo</th>
        <th>Placa</th>
        <th>Valor Diario</th>
        <th>Quantidade</th>
        <th>Valor Total</th>
      </tr>
    </thead>
    <tbody>
      {props.rel.length > 0 ? (
        props.rel.map(rel => (
          <tr>
            <td>{rel.carro.marca}</td>
            <td>{rel.carro.modelo}</td>
            <td>{rel.carro.placa}</td>
            <td>{rel.valorDiario}</td>
            <td>{rel.quantidade}</td>
            <td>{rel.valorFaturado}</td>
          </tr>
        ))
      ) : (
        <tr>
          <td colSpan={7}>Sem Dados de Faturamento</td>
        </tr>
      )}
    </tbody>
  </table>
)

export default FaturamentoTable
