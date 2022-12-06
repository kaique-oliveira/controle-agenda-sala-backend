import styled from "styled-components/native";

export const Container = styled.View`
    width: 100%;
    height: 60px;
    max-height: 60px;

    padding: 0 3px;
    justify-content: space-between;
    align-items: center;
    flex-direction: row;
    border-radius: 8px;
    border: 1px solid ${({theme}) => theme.COLORS.GRAY4};
    background-color: ${({ theme }) => theme.COLORS.GRAY6};
    box-shadow: 1px 3px 3px rgba(0,0,0,0.2);


`;

export const InputContainer = styled.TextInput`
    flex: 1;
    height: 60px;
    border: 0;
    border-radius: 8px;
    font-size: 15px;
    outline-width: 0;


`;
