import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.*;

/**
 * 
 */

/**
 * @author Tiago
 *
 */
public class Report {
	/**
	 * Report name
	 */
	private String name;
	
	/**
	 * Collection of profilers
	 */
	private Map<String, Profiler> profilers;
	
	/**
	 * Constructor
	 * @param name Report name
	 */
	public Report(String name) {
		this.name = name;
		this.profilers = new HashMap<String, Profiler>();
	}
	
	/**
	 * Add a profiler
	 * @param name Profiler name
	 * @param profiler Profiler to add
	 * @return True if added, otherwise false (Duplicated name)
	 */
	public boolean addProfiler(String name, Profiler profiler)
	{
		if(this.profilers.containsKey(name))
		{
			return false;
		}
		this.profilers.put(name, profiler);
		return true;
	}
	
	/**
	 * Add a profiler 
	 * @param name Profiler name
	 * @return Profiler added to map
	 */
	public Profiler addProfiler(String name)
	{
		if(this.profilers.containsKey(name))
		{
			return this.profilers.get(name);
		}
		Profiler profiler = new Profiler();
		this.profilers.put(name, profiler);
		return profiler;
	}

	/**
	 * Get a profiler
	 * @param name Profiler name
	 * @return Profiler, null if not exists
	 */
	public Profiler getProfiler(String name)
	{
		if(this.profilers.containsKey(name))
		{
			return this.profilers.get(name);
		}
		return null;
	}
	
	/**
	 * Write reports to a file
	 * @param path
	 */
	public void writeToFile(String path)
	{
		try
		{
			File file = new File(path, this.name+".txt");
			// Create file 

			FileWriter fstream = new FileWriter(file.getPath());
			BufferedWriter out = new BufferedWriter(fstream);
			out.write("# Relatório do algoritmo " + this.name);
			out.newLine();
			out.write("# Tempo de execução (ms)");
			out.newLine();
			
			Collection<Profiler> profilers = this.profilers.values();
			for(Profiler profiler : profilers)
			{
				out.write(String.valueOf(profiler.getExecutionMilliTime()));
				out.newLine();
			}
			
			//Close the output stream
			out.close();
			fstream.close();
		}catch (Exception e){ //Catch exception if any
			System.err.println("Error: " + e.getMessage());
		 }
	}
	
	/**
	 * Write reports to a file
	 */
	public void writeToFile()
	{
		this.writeToFile(Application.REPORTS_PATH);
	}
	
	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}
}
