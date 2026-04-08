using System;

public class Node {
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    
    // Construtor
    public Node(int key) {
        this.Key = key;
    }
}

// BST é Binary Search Tree
public class BST {
    public Node Raiz { get; set; }
    
    private Node InsertB(int valor, Node raiz){
        Node no = new Node(valor);
        if(raiz == null){
            return new Node(valor); 
        }
        if(valor < raiz.Key){
           raiz.Left = InsertB(valor, raiz.Left);
        } else {
           raiz.Right = InsertB(valor, raiz.Right);
        }
        return raiz;
        
    }
    
    public void Insert(int valor){
       this.Raiz = InsertB(valor, this.Raiz); 
    }
    
    private Node SearchB(int valor, Node raiz){
        if(raiz == null || raiz.Key == valor) return raiz;
        if(valor < raiz.Key) {
            return SearchB(valor, raiz.Left);
        } else {
            return SearchB(valor, raiz.Right);
        }
    }
    
    public Node Search(int valor){
        return SearchB(valor, this.Raiz);
    }
}

public class Program
{
	public static void Main()
	{
        BST arvore = new BST();
        
        arvore.Insert(10);
        arvore.Insert(5);
        arvore.Insert(15);
        arvore.Insert(3);
        
        Node result = arvore.Search(5);
        Console.WriteLine(result != null ? $"Encontrado: {result.Key}" : "Não encontrado");
        
        Node notFound = arvore.Search(99);
        Console.WriteLine(notFound != null ? $"Encontrado: {notFound.Key}" : "Não encontrado");
    }
}