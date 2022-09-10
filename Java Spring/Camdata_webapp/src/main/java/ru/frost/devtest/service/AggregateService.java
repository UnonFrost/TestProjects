package ru.frost.devtest.service;

import java.util.Collection;
import java.util.concurrent.ExecutionException;

import ru.frost.devtest.domain.AggregateData;

public interface AggregateService {
	
	Collection<AggregateData> aggregate() throws InterruptedException, ExecutionException;

}
