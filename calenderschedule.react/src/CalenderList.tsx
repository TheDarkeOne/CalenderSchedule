import React, { useState, ChangeEvent, FormEvent } from 'react';
import { Schedule } from './Schedule'
import axios from 'axios';
import TimePicker from 'react-time-picker'

export const CalenderList = () => {
    const defaultProps:Schedule[] = [];

    const [schedules, setPosts]: [Schedule[], (schedules: Schedule[]) => void] = React.useState(defaultProps);
    
    const [schedule, setSchedule]: [Schedule | null, (schedule: Schedule) => void] = React.useState<Schedule | null>(null);

    const [loading, setLoading]: [boolean, (loading: boolean) => void] = React.useState<boolean>(true);
    const [names, setName] = useState("");
    const [years, setYear] = useState(0);
    const [months, setMonth] = useState(0);
    const [days, setDay] = useState(0);
    const [times, setTime] : [Date, (time: Date) => void] = useState<Date>(new Date());
    const [descriptions, setDescription] = useState("");

    const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setName(e.currentTarget.value);
    };

    const handleYearChange = (e: ChangeEvent<HTMLInputElement>) => { 
        
        setYear(parseInt(e.currentTarget.value));
    };

    const handleMonthChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setMonth(parseInt(e.currentTarget.value));
    };

    const handleDayChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setDay(parseInt(e.currentTarget.value));
    };


    const handleDescriptionChange = (e: ChangeEvent<HTMLInputElement>) => { 
        setDescription(e.currentTarget.value);
    };

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        
        const variable = {
            Id: 0,
            Name: names,
            Year: years,
            Month: months,
            Day: days,
            Time: times,
            Description: descriptions,
          }
        
        setSchedule(variable);

        console.log(schedule);
        console.log(variable);

        axios.post(`https://calender-api-ammon.herokuapp.com/api/calender/addcalender`, { variable })
        .then(res => {
            console.log(res);
            console.log(res.data);
          })
      };

    const [error, setError]: [string, (error: string) => void] = React.useState("");
    React.useEffect(() => {
        axios
        .get<Schedule[]>("https://calender-api-ammon.herokuapp.com/api/calender", {
        headers: {
            "Content-Type": "application/json"
        },
        }).then(response => {
            setPosts(response.data);
            setLoading(false);
          }).catch(ex => {
            const error =
            ex.response.status === 404
              ? "Resource not found"
              : "An unexpected error has occurred";
            setError(error);
            setLoading(false);
          });
    }, []);
    
    return (
        <div>
        <ul>
        <table>
            <thead>
                        <tr>
                            <th>Id</th>
                            <th>Portfolio Name</th>
                        </tr>
            </thead>
            <tbody>
            {
                schedules.map((schedule) =>(
                   <tr key={schedule.Id}>
                        <td>{schedule.Id}</td>
                        <td>{schedule.Name}</td>
                        <td>{schedule.Month}</td>
                        <td>{schedule.Day}</td>
                        <td>{schedule.Year}</td>
                        <td>{schedule.Time}</td>
                        <td>{schedule.Description}</td>
                   </tr>
                ))
            }
            </tbody>
       </table>
        </ul>
        {error && <p className="error">{error}</p>}

        <form onSubmit={handleSubmit}>
            <input type="text" placeholder="Name..." onChange={handleNameChange} value={names} />
            <input type="number" placeholder="Month..." onChange={handleMonthChange} value={months} />
            <input type="number" placeholder="Day..." onChange={handleDayChange} value={days} />
            <input type="number" placeholder="Year..." onChange={handleYearChange} value={years} />
            <input type="text" placeholder="Description..." onChange={handleDescriptionChange} value={descriptions} />
            <input type="submit" value="Submit" />
        </form>
      </div>
    );
};