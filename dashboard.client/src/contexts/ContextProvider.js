import { setCurrencyCode } from '@syncfusion/ej2/base';
import React , {createContext, useContext,useState} from 'react'

const StateContext = createContext();

const initialState = {
    chat: false,
    cart : false,
    userProfile:false,
    notification:false
}

export const ContextProvider = ({children}) => {
    const [activeMenu,setActiveMenu] = useState(true);
    const [isClicked,setIsClicked] = useState(initialState);
    const [screenSize, setScreenSize] = useState(undefined);
    const [currentColor, SetCurrentColor] = useState('#03C9D7')
    const [currentMode, SetCurrentMode] = useState('Light')
    const [themeSettings, setThemeSettings] = useState(false)
    const setMode = (e) => {
        SetCurrentMode(e.target.value);
        localStorage.setItem('themeMode',e.target.value);
        setThemeSettings(false);
    }

    const setColor = (color) => {
        SetCurrentColor(color)
        localStorage.setItem('colorMode', color);
        setThemeSettings(false);
    }
    const handleClick = (clicked) => {setIsClicked({...initialState, [clicked]: true})


    }


    return (
        <StateContext.Provider value={{
            activeMenu,
            setActiveMenu,
            isClicked,
            setIsClicked,
            handleClick,
            screenSize,
            setScreenSize,
            currentColor,currentMode,
            themeSettings, setThemeSettings,
            setColor, setMode
            }}>
            {children}
        </StateContext.Provider>
    )
}


export const useStateContext =() => useContext (StateContext)