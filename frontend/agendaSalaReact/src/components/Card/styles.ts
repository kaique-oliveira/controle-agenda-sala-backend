import styled from "styled-components/native";

export const Container = styled.View`
    width: 400px;
    height: 100px;

    flex-direction: column;
    justify-content: space-evenly;
    align-items: center;

    background-color: ${({ theme }) => theme.COLORS.GRAY5};
    border: 1px solid ${({ theme }) => theme.COLORS.GRAY4};
    
    border-radius: 5px;
`;

export const Title = styled.Text`

    font-family: ${({ theme }) => theme.FONTS.POPPINSMEDIUM};
`;

export const Descricao = styled.Text`

    font-family: ${({ theme }) => theme.FONTS.POPPINSREGULAR};
`;

export const Data = styled.Text`

    font-family: ${({ theme }) => theme.FONTS.POPPINSREGULAR};
`;
