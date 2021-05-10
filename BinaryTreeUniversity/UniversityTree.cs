using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeUniversity
{    
    class UniversityTree
    {
        //ROOT ES UN ATRIBUTO DE LA CLASE
        public PositionNode Root;
        public PositionNode NodoTemp = null;
        float higherValue = 0;

        //METODO PARA CREAR UN NODO
        public void CreatePosition(PositionNode parent,
            Position positionToCreate,
            string parentPositionName)
        {
            //CREO EL ROOT
            PositionNode newNode = new PositionNode();
            newNode.Position = positionToCreate;
            //IDENTIFICO SI EL ARBOL ESTA VACIO 
            if (Root == null)
            {
                Root = newNode;
                return;
            }            
            if (parent == null)
            {
                return;
            }
            //SI EL PARENT NO ES NULL, PREGUNTO SI ES EL QUE ESTOY BUSCANDO            
            if (parent.Position.Name == parentPositionName)
            {
                //SI NO HAY NADA EN LA IZQUIERDA SE CREA LA NUEVA POSICION
                if (parent.Left == null)
                {
                    parent.Left = newNode;
                    return;
                }
                //SI ESTA OCUPADO VOY A LA DERECHA
                parent.Right = newNode;
                return;
            }            
            //BUSCO POR LA DERECHA Y POR LA IZQUIERDA
            CreatePosition(parent.Left, positionToCreate, parentPositionName);
            CreatePosition(parent.Right, positionToCreate, parentPositionName);
        }

        //METODO PARA IMPRIMIR EL ARBOL        
        public void PrintTree(PositionNode from)
        {
            if (from == null)
            {
                return;
            }
            
            Console.WriteLine("{0,28} {1,6} {2,6} {3,8}", $"{from.Position.Name}:", $"{from.Position.Salary}", $"{from.Position.PorTax}", $"{from.Position.TaxValue}");
            
            //LLAMADO RECURSIVO PARA IMPRIMIR IZQUIERDA Y DERECHA
            PrintTree(from.Left);
            PrintTree(from.Right);            
        }
        //METODO PARA SUMAR LOS SALARIOS
        public float SumSalaries(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            
            return from.Position.Salary + SumSalaries(from.Left) + SumSalaries(from.Right);
        }

        //BUSCO EL SALARIO MAYOR POR LA DERECHA Y POR LA IZQUIERDA
        public float SalaryHigher(PositionNode from)
        {            
            if (from != null)
            {
                if (higherValue < from.Position.Salary)
                {
                    higherValue = from.Position.Salary;
                }

                float higherValueLeft = SalaryHigher(from.Left);
                float higherValueRight = SalaryHigher(from.Right);

                if (higherValueLeft > higherValueRight)
                {
                    return higherValueLeft;
                }

                return higherValueRight;                
            }

            return higherValue;          
        }

        //CUENTO LOS NODOS PARA SACAR EL PROMEDIO 
        public float Count(PositionNode from)
        {                       
            if (from == null)
            {
                return 0;
            }
          
            float countLeft = Count(from.Left);
            float countRight = Count(from.Right);

            return countLeft + countRight + 1;            
        }
        
        //BUSCO EL NODO DESEADO PARA CALCULAR EL PROMEDIO DE SALARIOS
        public PositionNode SearchNodo(PositionNode from, String searchPosition)
        {   
            if (from != null)
            {                              
                //PREGUNTO SI EL NODO EN EL QUE ESTOY ES IGUAL AL CARGO A BUSCAR 
                if (from.Position.Name.Equals (searchPosition))
                {
                    return from;
                }
                else
                {   
                    //ALMACENO EN EL NODO TEMPORAL LA BUSQUEDA DE LA IZQUIERDA
                    NodoTemp = SearchNodo(from.Left, searchPosition);
                    if (NodoTemp == null)
                    {                        
                        NodoTemp = SearchNodo(from.Right, searchPosition);
                    }
                }                
            }
            return NodoTemp;
        }
                
        //METODO PARA SUMAR LOS IMPUESTOS 
        public float SumTax(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
           
            return from.Position.TaxValue + SumTax(from.Left) + SumTax(from.Right);            
        }
    }
}
