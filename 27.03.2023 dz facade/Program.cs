using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._03._2023_dz_facade
{
    internal class Program
    {
        class GPU
        {
            static public void StartGPU() { Console.WriteLine("Запуск видеокарты"); }
            static public void CheckGPU() { Console.WriteLine("Проверка связи с монитором"); }
            static public void RAMGPU() { Console.WriteLine("Bывод данных об оперативной памяти"); }
            static public void DiskReaderGPU() { Console.WriteLine("Вывод информации об устройстве чтения дисков"); }
            static public void WinchesterGPU() { Console.WriteLine("Bывод данных о винчестере"); }
            static public void StopGPU() { Console.WriteLine("Вывести на монитор данные прощальное сообщение"); }
        }
        class RAM
        {
            static public void StartRAM() { Console.WriteLine("Запуск устройств"); } 
            static public void CheckRAM() { Console.WriteLine("Анализ памяти"); }
            static public void ClearRAM() { Console.WriteLine("Отчистка памяти");  }
        }
        class Winchester
        {
            static public void StartWincester() { Console.WriteLine("Запуск винчестера"); }
            static public void CheckWincester() { Console.WriteLine("Проверка загрузочного блока"); }
            static public void StopWinchester() { Console.WriteLine("Остановка устройства"); }
        }
        class DiscReader
        {
            static public void StartDiscReader() { Console.WriteLine("Запуск устройства для чтения дисков"); }
            static public void CheckDiscReader() { Console.WriteLine("Проверка наличия дисков"); }
            static public void ReturnDiscReaderPosition() { Console.WriteLine("Возврат на текущую позицию"); }
        }
        class PowerSupply
        {
            static public void StartPowerSupply() { Console.WriteLine("Подать питание"); }
            static public void GPUPowerSupply() { Console.WriteLine("Подать питание на видеокарту"); }
            static public void RAMPowerSupply() { Console.WriteLine("Подать питание на оперативную память"); }
            static public void DiscReaderPowerSupply() { Console.WriteLine("Подать питание на устройство чтения дисков"); }
            static public void WinchesterPowerSupply() { Console.WriteLine("Подать питание на винчестер"); }
            static public void StopGPUPowerSupply() { Console.WriteLine("Прекратить питание видео карты"); }
            static public void StopRAMPowerSupply() { Console.WriteLine("Прекратить питание оперативной памяти"); }
            static public void StopDiscReaderPowerSupply() { Console.WriteLine("Прекратить питание устройства чтения дисков"); }
            static public void StopWinchesterPowerSupply() { Console.WriteLine("Прекратить питание винчестера"); }
            static public void StopPowerSupply() { Console.WriteLine("Выключение"); }
        }
        class Sensors
        {
            static public void CheckVoltage() { Console.WriteLine("Проверить напряжение"); }
            static public void CheckPowerSupplyTemperature() { Console.WriteLine("Проверить температуру в блоке питания");}
            static public void CheckGPUTemperature() { Console.WriteLine("Проверит температуру в видео карте"); }
            static public void CheckRAMTemperatyre() { Console.WriteLine("Проверить температуру в оперативной памяти"); }
            static public void CheckAllTemperature() { Console.WriteLine("Проверить температуру всех систем"); }
        }
        class FacadePC
        {
            private GPU gpu;
            private RAM ram;
            private Winchester winchester;
            private DiscReader discReader;
            private PowerSupply powerSupply;
            private Sensors sensors;
            public FacadePC() { }
            public void BeginWork()
            {
                PowerSupply.StartPowerSupply();
                Sensors.CheckVoltage();
                Sensors.CheckPowerSupplyTemperature();
                Sensors.CheckGPUTemperature();
                PowerSupply.StopGPUPowerSupply();
                GPU.StartGPU();
                GPU.CheckGPU();
                Sensors.CheckRAMTemperatyre();
                PowerSupply.RAMPowerSupply();
                RAM.StartRAM();
                RAM.CheckRAM();
                GPU.RAMGPU();
                PowerSupply.StopDiscReaderPowerSupply();
                DiscReader.StartDiscReader();
                DiscReader.CheckDiscReader();
                GPU.DiskReaderGPU();
                PowerSupply.WinchesterPowerSupply();
                Winchester.StartWincester();
                Winchester.CheckWincester();
                GPU.WinchesterGPU();
                Sensors.CheckAllTemperature();
            }
            /*1. Винчестер: остановка устройства.
2. Оперативная память: очистка памяти.
3. Оперативная память: анализ памяти.
4. Видео карта: вывести на монитор данные прощальное сообщение.
5. Устройство чтения дисков: вернуть в исходную позицию.
6. Блок питания: прекратить питание видео карты.
7. Блок питания: прекратить питание оперативной памяти.
8. Блок питания: прекратить питание устройства чтения дисков.
9. Блок питания: прекратить питание винчестера.
10.Датчики проверить напряжение.
11.Блок питания: выключение*/
            public void StopWork()
            {
                Winchester.StopWinchester();
                RAM.ClearRAM();
                RAM.CheckRAM();
                GPU.StopGPU();
                DiscReader.ReturnDiscReaderPosition();
                PowerSupply.StopGPUPowerSupply();
                PowerSupply.StopRAMPowerSupply();
                PowerSupply.StopDiscReaderPowerSupply();
                PowerSupply.StopWinchesterPowerSupply();
                Sensors.CheckVoltage();
                PowerSupply.StopPowerSupply();
            }
        }
        class User
        {
            public User() { }
            public void Work()
            {
                FacadePC facadePC = new FacadePC();
                facadePC.BeginWork();
                Console.WriteLine("\n\n\n\n------------------------------------------------------------------------\n\n\n\n");
                facadePC.StopWork();
            }
        }
        static void Main(string[] args)
        {
            User user = new User();
            user.Work();
        }
    }
}
