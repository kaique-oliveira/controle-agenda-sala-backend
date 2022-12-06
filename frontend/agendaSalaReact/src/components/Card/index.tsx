import React from 'react'

import { Container, Title, Descricao, Data } from './styles';

const Card: React.FC = () => {
    return (
        <Container>
            <Title>Kaique Oliveira - Desenvolvimento Web</Title>
            <Descricao>Sala de reunião térrio</Descricao>
            <Data>06/12/2022 - 12:00:00 ás 13:10:00</Data>
        </Container>
    );
}

export { Card };