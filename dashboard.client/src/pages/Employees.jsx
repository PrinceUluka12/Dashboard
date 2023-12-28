import { useEffect, useState } from 'react';
import { DataManager ,WebApiAdaptor } from '@syncfusion/ej2-data';
import { GridComponent, ColumnsDirective, ColumnDirective, Toolbar, Page, Search, Inject } from '@syncfusion/ej2-react-grids'
import { employeesGrid , fetchData} from '../data/dummy'
import { Header } from '../components'
import axios from 'axios';
const Employees = () => {
  const [data, setData] = useState(0);
  useEffect(() => {
    const fetchData = async () => {
      const result = await fetch('https://localhost:5113/api/EmployeesData')
      result.json().then(json => {
        setData(json);
      })
    }
    fetchData();
  }, []);
  return (

    <div className='m-2 md:m-10 p-2 md:p-10 bg-white rounded-3xl'>
      <Header title="Employees" category="Page"/>
          <GridComponent
       dataSource={data}
      allowPaging
      allowSorting
      toolbar={['Search']}
      width="auto"

      >
        <ColumnsDirective>
          {employeesGrid.map((item,index) => (
            <ColumnDirective key={index} {...item}/>
          ))}
        </ColumnsDirective>
        <Inject services={[Page,Search, Toolbar]}/>
      </GridComponent>
    </div>
  )
}

export default Employees