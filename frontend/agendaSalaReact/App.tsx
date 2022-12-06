import React from 'react';
import ApppLoading from 'expo-app-loading'
import { NavigationContainer } from '@react-navigation/native';
import { LoginProvider } from './src/contexts/contextoLogin';
import { ThemeProvider } from 'styled-components/native';

import {
  useFonts,
  Poppins_300Light,
  Poppins_400Regular,
  Poppins_500Medium,
  Poppins_700Bold,
  Poppins_800ExtraBold
} from '@expo-google-fonts/poppins';

import { DMSans_400Regular } from '@expo-google-fonts/dm-sans';
import {DMSerifDisplay_400Regular} from '@expo-google-fonts/dm-serif-display';

import Routes from './src/routes';
import COLORS from './src/styles/theme'

const App: React.FC = () => {

  const [fonsLoaded] = useFonts({
    Poppins_300Light,
    Poppins_400Regular,
    Poppins_500Medium,
    Poppins_700Bold,
    Poppins_800ExtraBold,
    DMSans_400Regular,
    DMSerifDisplay_400Regular
  });

  if (!fonsLoaded) {
    return <ApppLoading />
  }

  return (
    <ThemeProvider theme={COLORS}>
      <NavigationContainer>
        <LoginProvider> 
          <Routes />
        </LoginProvider>
      </NavigationContainer>
    </ThemeProvider>
  );
};

export default App;

