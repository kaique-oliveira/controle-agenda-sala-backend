import styled from 'styled-components/native'


export const Container = styled.View`
    flex: 1;
    min-height: 300px;
    min-width: 300px;
    align-items: center;
    padding: 5px;
    justify-content: center;
    background-color: ${({theme}) => theme.COLORS.WHITE_100};
`;

export const ContainerHeader = styled.View`
    height: 25%;
    width: 100%;
    padding-top: 40px;
    align-items: center; 
    justify-content: center;
`;

export const ContainerBody = styled.View`
    width: 100%;
    height: 60%;

    justify-content: space-evenly;
    flex-direction: column;
    align-items: center;
    padding-top: 50px;
`;

export const ContainerInput = styled.View`
    width: 95%;
    max-width: 500px;
    height: 150px;

    justify-content: space-between;
    flex-direction: column;
    align-items: center;
`;

export const ContainerFooter = styled.View`
    width: 100%;
    height: 15%;
    justify-content: flex-start;
    flex-direction: column;
    align-items: center;
`;


export const Title = styled.Text`
    margin-top: 15px;
    font-size: 25px;
    text-align: center;
    font-family: ${({ theme }) => theme.FONTS.POPPINSMEDIUM};
    
`;

export const Logo = styled.Image`
    width: 300px;
    height: 50px;
   
`;

export const Descrition = styled.Text`
    color: ${({theme}) => theme.COLORS.BLUE2};
    font-size: 15px;
    font-family: ${({ theme }) => theme.FONTS.POPPINSLIGHT};
    
`;





